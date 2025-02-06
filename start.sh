#!bin/bash

# if [[ ! -f /SharpBarberAPI/* ]]; then
#     dotnet new webapi -n SharpBarberAPI --force # --force creates template
#     dotnet restore
# fi

cd SharpBarberAPI
dotnet run
