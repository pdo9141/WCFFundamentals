https://blogs.msdn.microsoft.com/cclayton/2013/05/21/understanding-application-domains/
https://msdn.microsoft.com/en-us/library/ee358764(v=vs.110).aspx
https://msdn.microsoft.com/en-us/library/bb332338.aspx
https://channel9.msdn.com/shows/Endpoint/endpointtv-Screencast-Configuring-WAS-for-TCP-Endpoints/
https://blogs.msdn.microsoft.com/tomholl/2008/07/12/msmq-wcf-and-iis-getting-them-to-play-nice-part-1/
To Enable IIS/WAS/WCF/MSMQ
	Grant application web.config file permission to IIS_IUSRS (IIS Pool Identity)
	Grant message queue permission to IIS_IUSRS (not sure if this is neccessary)
	Ensure all Windows Process Activation Service options are configured in Windows Features (.NET Environment, Process Model, etc.)
	Ensure .NET Framework 3.5 options are configured in Windows Features (WCF HTTP Activation, WCF Non-HTTP Activation)
	Open command prompt as admin and cd to C:\Windows\System32\inetsrv\config notepad applicationHost.config (view sites node, see if bindings exists)
	If not, command prompt into C:\Windows\System32\inetsrv\ and type the following command to enable your site:
		appcmd.exe set site "Default Web Site" -+bindings.[protocol='net.tcp',bindingInformation='808:*'] (optional if not there in config)
		appcmd.exe set site "Default Web Site" -+bindings.[protocol='net.pipe',bindingInformation='*'] (optional if not there in config)
		appcmd.exe set site "Default Web Site" -+bindings.[protocol='net.msmq',bindingInformation='localhost'] (optional if not there in config)
		appcmd.exe set app "Default Web Site/AcmeWeb" /enabledProtocols:http,net.pipe,net.tcp,net.msmq
		