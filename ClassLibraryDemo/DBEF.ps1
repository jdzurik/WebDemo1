  $ConString = $("Data Source=99.133.184.235;Initial Catalog=Demo1;User Id=DemoUser;Password=DemoPass123;Connect Timeout=120;")
  $SQLQuery = $("SELECT distinct TABLE_SCHEMA, TABLE_CATALOG FROM INFORMATION_SCHEMA.COLUMNS")
 
    $Connection = New-Object System.Data.SQLClient.SQLConnection
    $Connection.ConnectionString = $ConString
    
    $Command = New-Object System.Data.SQLClient.SQLCommand
    $Command.Connection = $Connection
    $Command.CommandText = $SQLQuery
 
    
    $Connection.Open()
    $Reader = $Command.ExecuteReader()
    while ($Reader.Read()) {
        $Cmdef = $("Remove-Item -Path .\"+$Reader.GetValue(0)+"\*.cs")
        Write-Output $Cmdef
        Invoke-Expression $Cmdef
    }
    $Connection.Close()
    
    $Connection.Open()
    $Reader = $Command.ExecuteReader()
    while ($Reader.Read()) {
        $Cmdef = $("dotnet ef dbContext scaffold '"+ $ConString +"' Microsoft.EntityFrameworkCore.SqlServer -f -d -o "+$Reader.GetValue(0)+" -c "+$Reader.GetValue(1)+""+$Reader.GetValue(0)+"Context --schema "+$Reader.GetValue(0))
        Invoke-Expression $Cmdef
    }
    $Connection.Close() 
     
        $Connection.Open()
    $Reader = $Command.ExecuteReader()
    while ($Reader.Read()) {
          $Cmdef = $("((Get-Content -path .\"+$Reader.GetValue(0)+"\"+$Reader.GetValue(1)+""+$Reader.GetValue(0)+"Context.cs -Raw) -replace 'optionsBuilder.UseSqlServer','if (System.Configuration.ConfigurationManager.ConnectionStrings["""+$Reader.GetValue(1)+"_"+$Reader.GetValue(0)+"_ConStr""] != null) { optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["""+$Reader.GetValue(1)+"_"+$Reader.GetValue(0)+"_ConStr""].ConnectionString); } else optionsBuilder.UseSqlServer') | Set-Content -Path .\"+$Reader.GetValue(0)+"\"+$Reader.GetValue(1)+""+$Reader.GetValue(0)+"Context.cs") 
        
        Write-Output $Cmdef
        
        Invoke-Expression $Cmdef
    }
    $Connection.Close()
 
  <# Include these : Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass #>
  <# update EF TOOLING: dotnet tool update --global dotnet-ef #>
  <# add these nuget packages: microsoft.entityframeworkcore.sqlserver  #>
  <# add these nuget packages: microsoft.entityframeworkcore.design  #>
  <# add these nuget packages: system.configuration.configurationmanager  #>
