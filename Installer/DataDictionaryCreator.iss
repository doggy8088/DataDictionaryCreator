; Installer script for Data Dictionary Creator
; Requires Inno Setup - http://www.jrsoftware.org/isinfo.php
;
[Setup]
AppName=DataDictionaryCreator
AppVerName=Data Dictionary Creator v1.3.3
AppVersion=1.3
VersionInfoVersion=1.3
DefaultDirName={pf}\DataDictionaryCreator
DefaultGroupName=Data Dictionary Creator
DisableStartupPrompt=true
DisableProgramGroupPage=yes
ShowLanguageDialog=yes
ChangesAssociations=false
AppendDefaultGroupName=false
AppPublisher=Jon Galloway, VelocIT
AppPublisherURL=http://www.veloc-it.com/
SetupIconFile="D:\My Documents\Projects\DDC\trunk\DataDictionaryCreator\app.ico"
;This is not a typo. Need {{ to escape the first {
AppID={{F19A19B6-8FB3-4dc7-A10A-A6BF02BB4ECD}
SourceDir="D:\My Documents\Projects\DDC\trunk\DataDictionaryCreator\bin\Release"
OutputDir=..\..\..\..\Installer
OutputBaseFilename=DirectoryDictionaryCreator-v1.3.3-Setup

[Code]
const
  dotnetRedist11URL = 'http://download.microsoft.com/download/a/a/c/aac39226-8825-44ce-90e3-bf8203e74006/dotnetfx.exe';
  dotnetRedist20URL = 'http://download.microsoft.com/download/5/6/7/567758a3-759e-473e-bf8f-52154438565a/dotnetfx.exe';

function InitializeSetup(): Boolean;
var
    ErrorCode: Integer;
    NetFrameWorkInstalled : Boolean;
    InstallDotNetResponse : Boolean;

begin
          NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\.NETFramework\policy\v1.0');
          if NetFrameWorkInstalled =true then
          begin
              Result := true;
          end;
          if NetFrameWorkInstalled = false then
          begin
               NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\.NETFramework\policy\v1.1');
               if NetFrameWorkInstalled =true then
               begin
                  Result := true;
               end;
          end;
          if NetFrameWorkInstalled = false then
          begin
               NetFrameWorkInstalled := RegKeyExists(HKLM,'SOFTWARE\Microsoft\.NETFramework\policy\v2.0');
               if NetFrameWorkInstalled =true then
               begin
                  Result := true;
               end;
          end;
          if NetFrameWorkInstalled =false then
               begin
                  InstallDotNetResponse := MsgBox('This setup requires the .NET Framework. Please download and install the .NET Framework and run this setup again. Do you want to download the framework now?',mbConfirmation,MB_YESNO)= idYes;
                  if InstallDotNetResponse =false then
                    begin
                      Result:=false;
                    end
                  else
                    begin
                      Result:=false;
                      ShellExec('open',dotnetRedist20URL,'','',SW_SHOWNORMAL,ewNoWait,ErrorCode);
                    end;
               end;
end;
[Files]
Source: DataDictionaryCreator.exe; DestDir: {app}
Source: DataDictionaryCreator.exe.config; DestDir: {app}
Source: *.dll; DestDir: {app}
Source: Readme.txt; DestDir: {app}; Flags: isreadme
Source: xsl\*.xslt; DestDir: {app}\xsl
[Icons]
Name: "{group}\Data Dictionary Creator"; Filename: "{app}\DataDictionaryCreator.EXE"; WorkingDir: "{app}"
Name: "{group}\Uninstall"; Filename: "{uninstallexe}"
