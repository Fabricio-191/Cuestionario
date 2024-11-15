$score=0

Write-Host "Cual es la capital de francia ?"
$last_answer = Read-Host "Respuesta"

if ($last_answer.ToLower() -eq "paris"){ $score += 1 }

Write-Host "Cual es la capital de Alemania ?"
$last_answer = Read-Host "Respuesta"

if ($last_answer.ToLower() -eq "berlin"){ $score += 1 }

Write-Host "Cuanto es 3 * 12 ?"
$last_answer = Read-Host "Respuesta"

if ($last_answer.ToLower() -eq "36"){ $score += 1 }

Write-Host "Despeje la siguiente ecuacion: 2x + 3 = 7"
$last_answer = Read-Host "Respuesta"

if ($last_answer.ToLower() -eq "2"){ $score += 1 }

Write-Host "Cual es la estrella mas grande del sistema solar ?"
$last_answer = Read-Host "Respuesta"

if ($last_answer.ToLower() -like "sol"){ $score += 1 }

Write-Host "Cual es tu edad ?"
$last_answer = Read-Host "Respuesta"

Write-Host Your score is $score out of 5
