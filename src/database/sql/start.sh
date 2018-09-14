#!/bin/bash
wait_time=20s

echo creating resources in $wait_time
sleep $wait_time
echo starting...

echo 'creating Hotels DB'
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -i ./init.sql

echo 'creating Hotels Table'
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P $SA_PASSWORD -i ./data/HotelTable.sql

echo 'importing data...' # -F2 option to skip first row
/opt/mssql-tools/bin/bcp Hotels in data/Hotels.csv -S 0.0.0.0 -U sa -P $SA_PASSWORD -d Hotels -F2 -c -t ',' -e data/err.log

echo 'add uniqueid column'
/opt/mssql-tools/bin/sqlcmd -S localhost -d Hotels -U SA -P $SA_PASSWORD -I -Q "ALTER TABLE Hotels ADD ID UniqueIdentifier DEFAULT newid() NOT NULL;"

echo 'checking data'
/opt/mssql-tools/bin/sqlcmd -S localhost -d Hotels -U SA -P $SA_PASSWORD -I -Q "SELECT TOP 5 ID,[Name] FROM Hotels;"