#!/bin/bash

set -e
run_cmd="dotnet konoha.dll"

until dotnet ef database update; do
>&2 echo "SQL Server is starting up"
sleep 1
done

until dotnet user-secrets set Authentication:Facebook:AppId $AppId; do
>&2 echo "Update AppId Facebook"
sleep 1
done

until dotnet user-secrets set Authentication:Facebook:AppSecret $AppSecret do
>&2 echo "Update AppId Facebook"
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd