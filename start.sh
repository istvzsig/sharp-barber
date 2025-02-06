#!bin/bash

cd SharpBarberAPI
dotnet build
dotnet run &

cd ..

cd SharpBarberUI
ng serve
