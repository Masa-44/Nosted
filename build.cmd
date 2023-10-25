@echo off

:: Kill running instance of container
docker kill ijustkeeptryingiguess

:: Builds image specified in Dockerfile
docker image build -t ijustkeeptryingiguess .

:: Starts container with web application and maps port 80 (ext) to 80 (internal)
docker container run --rm -it -d --name ijustkeeptryingiguess --publish 80:80 ijustkeeptryingiguess

echo.
echo "Link: http://localhost:80/"
echo.

pause