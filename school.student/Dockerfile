#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["school.student/school.student.csproj", "school.student/"]
RUN dotnet restore "school.student/school.student.csproj"
COPY . .
WORKDIR "/src/school.student"
RUN dotnet build "school.student.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "school.student.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "school.student.dll"]