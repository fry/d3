This repository contains my work on reverse engineering D3

extract_protobins.py
---------------------
A small IDA script to extract the compact binary representations of the
protocol buffers definition files from executables.
In Diable 3, the required files are included in "Diablo III.exe" and
"battle.net.dll" and can be extracted by running the script from within
IDA on both databases.
