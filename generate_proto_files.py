import subprocess
import sys
import os

if len(sys.argv) < 3:
	print "Usage: %s in_dir out_dir" % sys.argv[0]
	sys.exit()

in_dir = sys.argv[1]
out_dir = sys.argv[2]

in_files = []
for root, dirs, files in os.walk(in_dir):
	for file in files:
		in_files.append(os.path.join(root, file))

#for file in in_files:
#	print "Building " + file
subprocess.call([
	"protogen",
	"--proto_path=%s" % in_dir,
	"--include_imports",
	"-service_generator_type=GENERIC",
	"-expand_namespace_directories=true",
	"-cls_compliance=false",
	"-ignore_google_protobuf=true",
	"-output_directory=%s" % out_dir] + in_files)
