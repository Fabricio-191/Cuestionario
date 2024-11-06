@echo off
setlocal enabledelayedexpansion

set /a score=0

echo Bienvenido al cuestionario!

echo.
echo Pregunta 1: �Cu�l es la capital de Francia?
echo A) Madrid
echo B) Par�s
echo C) Roma
set /p answer1=Respuesta: 
if /i "!answer1!"=="B" (
	echo asd
	set /a score+=1
)

echo.
echo Pregunta 2: �Cu�l es el resultado de 5 + 7?
echo A) 10
echo B) 12
echo C) 14
set /p answer2=Respuesta: 
if /i "!answer2!"=="B" (
	set /a score+=1
)

echo.
echo Pregunta 3: �Cu�l es el oc�ano m�s grande del mundo?
echo A) Atl�ntico
echo B) ?ndico
echo C) Pac�fico
set /p answer3=Respuesta: 
if /i "!answer3!"=="C" (
	set /a score+=1
)

echo.
echo Has terminado el cuestionario.
echo Tu puntuaci�n es: !score! de 3.

endlocal
pause