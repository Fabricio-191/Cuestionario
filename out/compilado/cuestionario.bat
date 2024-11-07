set /a score=0

echo "Cual es la capital de francia ?"
set /p last_answer="Respuesta: "

if "%last_answer%" == "paris" (
	set /a score+=1
)
echo "Cual es la capital de Alemania ?"
set /p last_answer="Respuesta: "

if "%last_answer%" == "berlin" (
	set /a score+=1
)
echo "Cuanto es 3 * 12 ?"
set /p last_answer="Respuesta: "

if "%last_answer%" == "36" (
	set /a score+=1
)
echo "Despeje la siguiente ecuacion: 2x + 3 = 7"
set /p last_answer="Respuesta: "

if "%last_answer%" == "2" (
	set /a score+=1
)
echo "Cual es la estrella mas grande del sistema solar ?"
set /p last_answer="Respuesta: "

if not x%last_answer:"sol"=% == x%last_answer% (
	set /a score+=1
)
echo "Cual es tu edad ?"
set /p last_answer="Respuesta: "

echo Your score is %score% out of 5
