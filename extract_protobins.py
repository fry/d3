import idautils
import idc
import os

# find the next function call starting at ea
def NextFunctionCall(ea, maxea = None):
	if not maxea:
		maxea = idc.NextFunction(ea)

	# skip the input instruction
	for inst in idautils.Heads(idc.NextHead(ea, maxea), maxea):
		inst = idautils.DecodeInstruction(inst)
		# skip ahead if it is not a call instruction
		if inst.itype == 16:
			return inst.ea

	return None

def DumpProtoBin(root_dir, file_name, data, length):
	data = idc.GetManyBytes(data, length)

	full_file_name = os.path.join(root_dir, file_name + "bin")
	directory = os.path.dirname(full_file_name)

	if not os.path.exists(directory):
		os.makedirs(directory)

	file = open(full_file_name, "wb")
	file.write(data)
	file.close()

# output the definition files to the following folder
script_path = os.path.dirname(os.path.realpath(__file__))
out_dir = os.path.join(script_path, "definitions_bin")

# find the function referencing all the binary protobuf representations
DescriptorPool__InternalAddGeneratedFile = idc.FindBinary(INF_BASEADDR, SEARCH_DOWN,
	"55 8B EC 6A FF 68 ? ? ? ? 64 A1 00 00 00 00 50 83 EC 38 A1 ? ? ? ? 33 C5 50 8D 45 F4 64 A3 00 00 00 00 C7 45 C4 00 00 00 00 E8 ? ? ? ?")

for ref in idautils.XrefsTo(DescriptorPool__InternalAddGeneratedFile):
	# TODO: make a GetParameters function
	push_data = idautils.DecodePrecedingInstruction(ref.frm)[0]
	data = push_data.Op1.value

	push_length = idautils.DecodePrecedingInstruction(push_data.ea)[0]
	length = push_length.Op1.value

	# find the call to the function containing the proto filename
	gen_file_call = NextFunctionCall(ref.frm)
	push_name = idautils.DecodePrecedingInstruction(gen_file_call)[0]
	file_name = GetString(push_name.Op1.value)

	print file_name, hex(data), hex(length)
	DumpProtoBin(out_dir, file_name, data, length)