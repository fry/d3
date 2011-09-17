This repository contains my work on reverse engineering D3

extract_protobins.py
--------------------
A small IDA script to extract the compact binary representations of the
protocol buffers definition files from executables.
In Diable 3, the required files are included in "Diablo III.exe" and
"battle.net.dll" and can be extracted by running the script from within
IDA on both databases.

decompile_protobins.py
----------------------
This script turns the .protobin binary representations of the protocol buffers
back into plain text .proto files. Requires the Google Protocol Buffers Python
library.

Usage: decompile_protobins.py in_folder out_folder
