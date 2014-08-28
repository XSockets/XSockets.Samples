XSockets.Windows.Service
========================

# Info

This is an simple example that shows how to run XSockets.NET as Windows Service.  

After successfull build Install the service by using the InstalUtil.exe, open command prompt (development console) in admin mode

Register (install) the service:

InstallUtil.exe XSockets.Windows.Service.exe

Unregister (Uninstall) the service

InstallUtil.exe XSockets.Windows.Service.exe /u

# Note

Do you have dependencies on external assemblies in your "controllers"?
Make sure to add them to the root of the service location.

To change configuration settings such as endpoint and allowed origins (location of your XSockets Service).
Apply your changes to the app.config ("XSockets.Windows.Service.Configuration")

The example configuration is defined to answer on the following url and origins;

Url: ws://127.0.0.1:4509"
Origins: http://*,https://*

As we included the XSockets.Controllers plugin you will be able
to use the "Generic" Controller (Just remove that assembly from the references to disable that functionallity.)

You can also connect with Putty and raw sockets 
since we included the custom protocols assembly.
Remove that assembly to disable connections from things like Putty, Netduino, Arduino etc

================================================


Regards
Team XSockets.NET