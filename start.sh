#!/bin/bash

set -e

echo "Starting Backend (SharpBarberAPI)..."
cd SharpBarberAPI
dotnet build SharpBarberAPI.csproj
dotnet run --project SharpBarberAPI.csproj &

sleep 5

echo "Initializing database..."
dotnet ef database update --project SharpBarberAPI.csproj

cd ..

echo "Starting Angular Frontend (SharpBarberUI)..."
cd SharpBarberUI
ng serve --open

wait
