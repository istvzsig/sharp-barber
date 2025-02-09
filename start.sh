#!/bin/bash

cd SharpBarberAPI

dotnet restore
dotnet ef migrations remove

rm sharpbarber.db

dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet build
dotnet run &

sleep 5

cd ..
cd SharpBarberUI
ng serve
