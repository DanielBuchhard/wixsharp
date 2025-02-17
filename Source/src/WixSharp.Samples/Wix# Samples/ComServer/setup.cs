﻿//css_dir ..\..\;
//css_ref Wix_bin\SDK\Microsoft.Deployment.WindowsInstaller.dll;
//css_ref System.Core.dll;
using System;
using WixSharp;

class Script
{
    static public void Main()
    {
        // You can also use `CommonTasks.RegisterComAssembly` to register COM servers.
        // Which is not a WiX/MSI recommended approach for COM registration, but may still
        // be a good choice of the registration technique.

        var project =
            new Project("MyProduct",
                new Dir(@"%ProgramFiles%\My Company\My Product",
                    new File(@"Files\Bin\MyApp.exe",
                             new TypeLib
                             {
                                 Id = new Guid("6f330b47-2577-43ad-9095-1861ba25889b"),
                                 Language = 33,
                                 MajorVersion = 23
                             },
                             new ComRegistration
                             {
                                 Id = new Guid("6f330b47-2577-43ad-9095-1861ba25889b"),
                                 Description = "MY DESCRIPTION",
                                 ThreadingModel = ThreadingModel.apartment,
                                 Context = "InprocServer32",
                                 ProgIds = new[]
                                 {
                                     new ProgId
                                     {
                                         Id = "PROG.ID.1",
                                         Description ="Version independent ProgID ",
                                         ProgIds = new[]
                                         {
                                             new ProgId
                                             {
                                                 Id = "prog.id",
                                                 Description="some description"
                                             }
                                         }
                                     }
                                 }
                             })));

        project.GUID = new Guid("6f330b47-2577-43ad-9095-1861ba25889b");
        project.PreserveTempFiles = true;

        project.BuildMsi();
    }
}