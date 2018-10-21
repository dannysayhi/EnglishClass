CREATE TABLE #Studrollcall_temp2( [CourseID] [int] , [StudentID] [int] , [TwName] [varchar](20) , [RollcallCount]  [varchar](5) , [RollcallTimes] [datetime] , [RollcallType] [varchar](2),  [RollcallMsg] [varchar](100)  ) 
Insert into #Studrollcall_temp2  Select EnglishClassDBtest.dbo.Table_CourseManagement.CourseID, EnglishClassDBtest.dbo.Table_CourseManagement.StudentID, EnglishClassDBtest.dbo.Table_StudentBasic.TwName, EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_20180709.RollcallCount,  EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_20180709.Rollcalltimes, EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_20180709.RollcallType, EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_20180709.RollcallMsg from EnglishClassDBtest.dbo.Table_CourseManagement left outer join EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_20180709 on EnglishClassDBtest.dbo.Table_CourseManagement.StudentID = EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_20180709.StudentID left outer join EnglishClassDBtest.dbo.Table_StudentBasic on EnglishClassDBtest.dbo.Table_StudentBasic.StudentID = EnglishClassDBtest.dbo.Table_CourseManagement.StudentID where EnglishClassDBtest.dbo.Table_CourseManagement.CourseID = '1'

--select * from  #Studrollcall_temp2
----select  DISTINCT  StudentID from  #Studrollcall_temp2
select * into #Studrollcall_temp4 from  #Studrollcall_temp2
select DISTINCT  StudentID into #Studrollcall_temp5 from #Studrollcall_temp4
select * from #Studrollcall_temp5

CREATE TABLE #Studrollcall_temp3( [CourseID] [int] , [StudentID] [int] , [TwName] [varchar](20) , [RollcallCount]  [varchar](5) , [RollcallTimes] [datetime] , [RollcallType] [varchar](2),  [RollcallMsg] [varchar](100)  ) 
 insert into #Studrollcall_temp3 Select * From #Studrollcall_temp2 Where [RollcallTimes] In (Select Max([RollcallTimes]) From #Studrollcall_temp2 Group By [StudentID])
 select * from #Studrollcall_temp3

Select #Studrollcall_temp3.CourseID,#Studrollcall_temp5.StudentID,#Studrollcall_temp3.TwName,#Studrollcall_temp3.RollcallCount,#Studrollcall_temp3.RollcallTimes,#Studrollcall_temp3.RollcallType,#Studrollcall_temp3.RollcallMsg
from #Studrollcall_temp5
left join #Studrollcall_temp3
on #Studrollcall_temp5.StudentID=#Studrollcall_temp3.StudentID


--select * from #Studrollcall_temp4
 --CREATE TABLE #Studrollcall_temp3( [CourseID] [int] , [StudentID] [int] , [TwName] [varchar](20) , [RollcallCount]  [varchar](5) , [RollcallTimes] [datetime] , [RollcallType] [varchar](2),  [RollcallMsg] [varchar](100)  ) 
 --insert into #Studrollcall_temp3 Select * From #Studrollcall_temp2 Where [RollcallTimes] In (Select Max([RollcallTimes]) From #Studrollcall_temp2 Group By [StudentID])
 
 --Select * From #Studrollcall_temp3 


 --Select EnglishClassDBtest.dbo.Table_CourseManagement.StudentID,EnglishClassDBtest.dbo.Table_StudentBasic.TwName, EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_20180709.RollcallCount,  EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_20180709.Rollcalltimes, EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_20180709.RollcallType, EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_20180709.RollcallMsg 
 --from EnglishClassDBtest.dbo.Table_CourseManagement 
 ----left outer join #Studrollcall_temp3
 ----on EnglishClassDBtest.dbo.Table_CourseManagement.StudentID = #Studrollcall_temp3.StudentID 
 --left outer join EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_20180709 
 --on EnglishClassDBtest.dbo.Table_CourseManagement.StudentID = EnglishClassDBtestRollcall.dbo.Table_StudentRollcall_20180709.StudentID 
 --left outer join EnglishClassDBtest.dbo.Table_StudentBasic 
 --on EnglishClassDBtest.dbo.Table_StudentBasic.StudentID = EnglishClassDBtest.dbo.Table_CourseManagement.StudentID 
 --where EnglishClassDBtest.dbo.Table_CourseManagement.CourseID = '1'



drop table #Studrollcall_temp2
drop table #Studrollcall_temp4
drop table #Studrollcall_temp5
drop table #Studrollcall_temp3