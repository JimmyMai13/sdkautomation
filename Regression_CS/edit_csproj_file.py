import os
import platform
import argparse


class EditCSProjFile:

    def __init__(self, build_machine):
        self.build_machine = build_machine

    def edit_file(self):
        if self.build_machine.lower() != "true":
            fp = "{}\\Regression_CS\\Regression_CS.csproj".format(os.getcwd())
        else:
            fp = "{}\\Regression_CS\\Regression_CS\\Regression_CS.csproj".format(os.getcwd())
        line_to_edit = ""
        with open(fp, 'r') as f:
            filedata = f.readlines()
            for each in filedata:
                if "..\\..\\resources\\Windows\\" in each:
                    line_to_edit = each

        arch = platform.machine()[-2:]
        if arch == '32':
            arch = "Win32"
        else:
            arch = "x64"

        if self.build_machine.lower() != "true":
            print(line_to_edit)
            hintpath = line_to_edit.index(">")
            endhintpath = [i for i, n in enumerate(line_to_edit) if n == '<'][1]
            hintpathvalue = line_to_edit[hintpath+1:endhintpath]
            print(hintpathvalue)
            arch = "..\\ISAgentSDKNetWrapper\\Release\\{}\\ISAgentSDKNetWrapper.dll".format(arch)
            with open(fp, 'r') as f:
                data = f.read()
                data = data.replace(hintpathvalue, arch)
        else:
            arch_to_edit = line_to_edit.split('\\')[4]
            with open(fp, 'r') as f:
                data = f.read()
                data = data.replace(arch_to_edit, arch)

        with open(fp, 'w') as f:
            f.write(data)

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="EditCSProjFile")
    parser.add_argument('--buildmachine', required=True, help='True for buildmachine, otherwise False for downstream')
    args = parser.parse_args()
    edit = EditCSProjFile(build_machine=args.buildmachine)
    edit.edit_file()
