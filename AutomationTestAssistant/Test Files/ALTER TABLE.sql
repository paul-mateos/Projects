ALTER TABLE dbo.[Member]
   ALTER COLUMN [Salt] nvarchar(MAX) not null
ALTER TABLE dbo.MemberRole
   ALTER COLUMN [Role] nvarchar(50) not null
ALTER TABLE dbo.TestResultRun
   ALTER COLUMN ExecutionLog nvarchar(MAX)  null

   
   
   
   ALTER TABLE dbo.TestResultRun
ADD CONSTRAINT FK_ExecutionResultRun_MethodID FOREIGN KEY (TestId)
    REFERENCES dbo.Test(TestId);
    
    
    ALTER TABLE dbo.TestResultRun DROP COLUMN TestId
    
    
    select * from dbo.TestResultRun
    
    
    ALTER TABLE dbo.TestResultRun
   ADD EndTime date not null