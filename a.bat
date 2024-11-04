@echo off
setlocal enabledelayedexpansion

set /a score=0

echo Bienvenido al cuestionario!

echo.
echo Pregunta 1: ¿Cuál es la capital de Francia?
echo A) Madrid
echo B) París
echo C) Roma
set /p answer1=Respuesta: 
if /i "!answer1!"=="B" (
	set /a score+=1
)

echo.
echo Pregunta 2: ¿Cuál es el resultado de 5 + 7?
echo A) 10
echo B) 12
echo C) 14
set /p answer2=Respuesta: 
if /i "!answer2!"=="B" (
	set /a score+=1
)

echo.
echo Pregunta 3: ¿Cuál es el océano más grande del mundo?
echo A) Atlántico
echo B) Índico
echo C) Pacífico
set /p answer3=Respuesta: 
if /i "!answer3!"=="C" (
	set /a score+=1
)

echo.
echo Has terminado el cuestionario.
echo Tu puntuación es: !score! de 3.

endlocal
pause