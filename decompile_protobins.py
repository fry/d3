# TODO:
# FileDescriptorProto:
# - message_type
# - enum_type
# - service
# - extension
# - options
# DescriptorProto
# - field
# - extension
# - nested_type
# - enum_type
# - extension_range
# - options

import os
import sys
import google.protobuf.descriptor_pb2 as pb2

class ProtobinDecompiler:
	label_map = {
		pb2.FieldDescriptorProto.LABEL_OPTIONAL: "optional",
		pb2.FieldDescriptorProto.LABEL_REQUIRED: "required",
		pb2.FieldDescriptorProto.LABEL_REPEATED: "repeated"
	}

	type_map = {
		pb2.FieldDescriptorProto.TYPE_DOUBLE: "double",
		pb2.FieldDescriptorProto.TYPE_FLOAT: "float",
		pb2.FieldDescriptorProto.TYPE_INT64: "int64",
		pb2.FieldDescriptorProto.TYPE_UINT64: "uint64",
		pb2.FieldDescriptorProto.TYPE_INT32: "int32",
		pb2.FieldDescriptorProto.TYPE_FIXED64: "fixed64",
		pb2.FieldDescriptorProto.TYPE_FIXED32: "fixed32",
		pb2.FieldDescriptorProto.TYPE_BOOL: "bool",
		pb2.FieldDescriptorProto.TYPE_STRING: "string",
		pb2.FieldDescriptorProto.TYPE_BYTES: "bytes",
		pb2.FieldDescriptorProto.TYPE_UINT32: "uint32",
		pb2.FieldDescriptorProto.TYPE_SFIXED32: "sfixed32",
		pb2.FieldDescriptorProto.TYPE_SFIXED64: "sfixed64",
		pb2.FieldDescriptorProto.TYPE_SINT32: "sint32",
		pb2.FieldDescriptorProto.TYPE_SINT64: "sint64"
	}

	def __init__(self):
		pass
	
	def decompile(self, file_name, out_dir = ".", stdout=False):
		file = open(file_name, "rb")
		data = file.read()
		file.close()
		descriptor = pb2.FileDescriptorProto.FromString(data)

		out = None
		if stdout:
			out = sys.stdout
		else:
			out_file_name = os.path.join(out_dir, descriptor.name)
			out_full_dir = os.path.dirname(out_file_name)
			if not os.path.exists(out_full_dir):
				os.makedirs(out_full_dir)
			out = open(out_file_name, "wb")
		
		self.indent_level = 0
		try:
			self.decompile_file_descriptor(out, descriptor)
		except:
			print "Failed decompiling %s" % file_name
			print "Descriptor dump:"
			print descriptor
			raise
		print "Decompiled %s" % file_name
	
	def decompile_file_descriptor(self, out, descriptor):
		# deserialize package name and dependencies
		if descriptor.HasField("package"):
			self.write(out, "package %s;\n\n" % descriptor.package)

		for dep in descriptor.dependency:
			self.write(out, "import \"%s\";\n" % dep)

		self.write(out, "\n")

		for msg in descriptor.message_type:
			self.decompile_message_type(out, msg)
	
	def decompile_message_type(self, out, msg):
		self.write(out, "message %s {\n" % msg.name)
		self.indent_level += 1

		# deserialize nested messages
		for nested_msg in msg.nested_type:
			self.decompile_message_type(out, nested_msg)

		# deserialize nested enumerations
		for nested_enum in msg.enum_type:
			self.decompile_enum_type(out, nested_enum)

		# deserialize fields
		for field in msg.field:
			# type name is either another message or a standard type
			type_name = ""
			if field.type == pb2.FieldDescriptorProto.TYPE_MESSAGE or field.type == pb2.FieldDescriptorProto.TYPE_ENUM:
				type_name = field.type_name
			else:
				type_name = self.type_map[field.type]
			
			# build basic field string with label name
			field_str = "%s %s %s = %d" % (self.label_map[field.label], type_name, field.name, field.number)

			# add default value if set
			if field.HasField("default_value"):
				field_str += " [default = %s]" % field.default_value
			field_str += ";\n"
			self.write(out, field_str)
		self.indent_level -= 1
		self.write(out, "}\n\n")
	
	def decompile_enum_type(self, out, enum):
		self.write(out, "enum %s {\n" % enum.name)
		self.indent_level += 1

		# deserialize enum values
		for value in enum.value:
			self.write(out, "%s = %d;\n" % (value.name, value.number))

		self.indent_level -= 1
		self.write(out, "}\n")

	def write(self, out, str):
		out.write("\t" * self.indent_level)
		out.write(str)

decomp = ProtobinDecompiler()

if len(sys.argv) < 3:
	print "Usage: %s in_folder out_folder" % sys.argv[0]
	sys.exit()

in_dir = sys.argv[1]
out_dir = sys.argv[2]

in_files = []
for root, dirs, files in os.walk(in_dir):
	for file in files:
		if file.endswith(".protobin"):
			in_files.append(os.path.join(root, file))

for file in in_files:
	decomp.decompile(file, out_dir)