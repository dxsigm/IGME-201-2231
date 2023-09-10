Beginning C Sharp - Chapter 23
==============================

Setting up the samples for this chapter
---------------------------------------

These instructions assume you are simply using the code files we are providing, rather than building
them yourself with reference to the chapter.

In order to open the project file you will first need to make the WebLog directory into
a Virtual Directory in IIS. IIS is a local web server which can be installed with Windows.
If you can't find the Internet Service Manager by following the steps below then you have not
installed IIS. To install IIS simply open up Add/Remove Programs, select the Install
Windows Components option on the left and check the IIS option. 

In order to make the WebLog directory into a Virtual Directory just follow these steps:

1) Open up Internet Services Manager by browsing through Start | Settings | Control Panel | Administrative Tools | Internet Services Manager.
2) In the ISM, right-click on the Default Web Site node in the left-hand pane and select New | Virtual Directory from the context menu which appears.
3) Click Next
4) Give the Virtual Directory the alias "WebLog" and click Next
5) Browse to the files for this chapter, at C:\BegVCSharp\Chapter23\WebLog, and click Next
6) Leave the defaults and click Next
7) Click Finish

You should now be able to open the .csproj file by simply double clicking it in Windows Explorer.