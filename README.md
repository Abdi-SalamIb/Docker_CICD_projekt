# Docker CI/CD Project – Personnummer Kontroll

This project demonstrates a simple **C# console application** that validates Swedish personal identity numbers (*personnummer*), packaged and deployed using **Docker** and **GitHub Actions (CI/CD)**.

The repository is part of a learning exercise focused on:
- Dockerizing .NET applications
- Automated build and test pipelines
- Collaborative development using Git and GitHub

---

## 📌 Project Overview

The application:
- Accepts a Swedish personal number as input
- Validates its format and checksum
- Outputs whether the personal number is valid or not

The project includes:
- A C# console application
- Unit tests
- A Dockerfile for containerization
- A GitHub Actions workflow for CI/CD

---

## 🧱 Project Structure

├── .github/workflows/ # CI/CD pipeline (GitHub Actions)
├── Dockerfile # Docker build configuration
├── Docker_CICD_projekt.sln # Solution file
├── PersonnummerKontrollApp.cs
├── PersonnummerKontrollApp.csproj
├── PersonnummerTests.cs
├── PersonnummerTests.csproj
└── README.md

---

## 🐳 Run with Docker

### Prerequisites
- Docker installed
- Git installe

### Build the Docker image
```bash
docker build -t personnummer-app .


