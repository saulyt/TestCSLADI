# TestCSLADI

This project adds a scoped dependency in Program.cs via builder.Services.AddScoped<ITestDI, TestDI>();

ITestDI is injected via Constructor injection to InjectionController, and also to the CSLABusinessObj FetchAsync via the CSLA [Inject] attribute

TestDI has a _createTime DateTime field that is set in it’s constructor. The value of that time is logged to the console in both the InjectionController Get action and the CSLABusinessObj FetchAsync method.

I am finding that:
-	On the first and second call to the API, both the InjectionController and CSLABusinessObj have their own new instances of the TestDI object. (I was expecting them both to have the same instance from the scoped dependency)
-	On every subsequent call, the InjectionController has a new instance of the object as expected, but the Fetch method still has the same object that was created on the second call.

Sample Output where you can see that the Fetch method keeps logging 07:38:38.409 PM from the 2nd call on:

info: TestCSLADI.Controllers.InjectionController[0]
      Create Time in InjectionController is:07:38:34.858 PM
info: TestCSLADI.Library.CSLABusinessObj[0]
      Create Time in CSLABusinessObj is:07:38:34.948 PM	  
info: TestCSLADI.Controllers.InjectionController[0]
      Create Time in InjectionController is:07:38:38.404 PM	  
info: TestCSLADI.Library.CSLABusinessObj[0]
      Create Time in CSLABusinessObj is:07:38:38.409 PM  
info: TestCSLADI.Controllers.InjectionController[0]
      Create Time in InjectionController is:07:38:44.447 PM  
info: TestCSLADI.Library.CSLABusinessObj[0]
      Create Time in CSLABusinessObj is:07:38:38.409 PM  
info: TestCSLADI.Controllers.InjectionController[0]
      Create Time in InjectionController is:07:38:49.041 PM 
info: TestCSLADI.Library.CSLABusinessObj[0]
      Create Time in CSLABusinessObj is:07:38:38.409 PM  
info: TestCSLADI.Controllers.InjectionController[0]
      Create Time in InjectionController is:07:38:53.721 PM	  
info: TestCSLADI.Library.CSLABusinessObj[0]
      Create Time in CSLABusinessObj is:07:38:38.409 PM  
info: TestCSLADI.Controllers.InjectionController[0]
      Create Time in InjectionController is:07:38:58.671 PM	  
info: TestCSLADI.Library.CSLABusinessObj[0]
      Create Time in CSLABusinessObj is:07:38:38.409 PM
