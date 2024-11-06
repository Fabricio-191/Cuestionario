set /a score=0
set /a last_answer=0
echo "Cual es la capital de francia ?"
set /p last_answer="Respuesta: "
if %last_answer% == "Paris" (
	set /a score+=1
)
echo "Cual es la capital de Alemania ?"
set /p last_answer="Respuesta: "
if %last_answer% == "Berlin" (
	set /a score+=1
)
echo "Cuanto es 3 * 12 ?"
set /p last_answer="Respuesta: "
if %last_answer% == "36" (
	set /a score+=1
)
echo "Despeje la siguiente ecuacion: 2x + 3 = 7"
set /p last_answer="Respuesta: "
if %last_answer% == "2" (
	set /a score+=1
)
echo "Cual es la estrella mas grande del sistema solar ?"
set /p last_answer="Respuesta: "
if %last_answer% == "Sol" (
	set /a score+=1
)
echo "Cual es tu edad ?"
set /p last_answer="Respuesta: "
if %last_answer% ==  (
	set /a score+=1
)
