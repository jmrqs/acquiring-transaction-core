echo "Waiting for SQL Server to start..."
sleep 20
./opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P "@qu1r1ngtr@ns@ct10nc0r3" -d master -i ./init.sql
echo "Seed script executed."
