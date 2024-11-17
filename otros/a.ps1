#!/bin/bash

$score=0

Write-Host "Bienvenido al cuestionario!"

Write-Host "Pregunta 1: ?Cu�l es la capital de Francia?"
Write-Host "A) Madrid"
Write-Host "B) Par�s"
Write-Host "C) Roma"

$answer = Read-Host "Respuesta"
$answer = $answer.ToUpper()

if ($answer -eq "B") {
	$score++
}

Write-Host ""
Write-Host "Pregunta 2: ?Cu�l es el resultado de 5 + 7?"
Write-Host "A) 10"
Write-Host "B) 12"
Write-Host "C) 14"

$answer = Read-Host "Respuesta"
$answer = $answer.ToUpper()

if ($answer -eq "B") {
	$score++
}

Write-Host ""
Write-Host "Pregunta 3: ?Cu�l es el oc�ano m�s grande del mundo?"
Write-Host "A) Atl�ntico"
Write-Host "B) �ndico"
Write-Host "C) Pac�fico"

$answer = Read-Host "Respuesta"
$answer = $answer.ToUpper()

if ($answer -eq "C") {
	$score++
}

Write-Host ""
Write-Host "Has terminado el cuestionario."
Write-Host "Tu puntuaci�n es: $score de 3."