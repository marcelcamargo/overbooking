FROM microsoft/aspnet:4.7.2
ARG source
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .
