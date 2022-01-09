# https://github.com/twright-msft/mssql-node-docker-demo-app

#run the setup script to create the DB and the schema in the DB
#do this in a loop because the timing for when the SQL instance is ready is indeterminate
for i in {1..50};
do
    /opt/mssql-tools/bin/sqlcmd -S mssql -U sa -P yourStrong_Password -d master -i /init.sql
    if [ $? -eq 0 ]
    then
        echo "init.sql completed"
        break
    else
        echo "not ready yet..."
        sleep 1
    fi
done
