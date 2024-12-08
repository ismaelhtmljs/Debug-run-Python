import os
import curses
import msvcrt
from colorama import *

def Program(): 
    while True:
        print("""
            
        """)
        print(Fore.LIGHTYELLOW_EX + "Para salir coloque 'exit' ")
        print(Fore.GREEN + "[1]Depurar")
        print(Fore.GREEN + "[2]Ver Archivos")
        print(Fore.GREEN + "[3]Moverse de Escritorio")
        print(Fore.GREEN + "[4]Abrir vscode")
        print(Fore.GREEN + "[5]Crear Proyecto")
        respuesta = input("C:")

        # condiciones para las opciones
        if respuesta == "1":
            Depurar()
            Limpiador()


def Depurar():
    print(Fore.RED + "Coloque el nombre de su archivo a ejecutar (solo el nombre, no la extencion)")
    nombre_archivo = input(Fore.GREEN + "Escriba el nombre de su archivo : ")
    
    # asegurarse si el nombre tiene la extencion
    if not nombre_archivo.endswith('.py'):
        nombre_archivo += '.py'
    
    # verificar si el archivo a depurar exite
    if os.path.exists(nombre_archivo):
        print("Depurando : \n")
        os.system(f"python {nombre_archivo}")
    else:
        print(Fore.RED + f"El archivo {nombre_archivo} no existe.")

def Limpiador():
    print("Presione ENTER para continuar...")
    
    # Solo permitirá presionar ENTER
    if os.name == 'nt':
        print("Presione cualquier tecla para continuar...")
        msvcrt.getch()  # Espera que el usuario presione cualquier tecla sin necesidad de Enter
        os.system('cls' if os.name == 'nt' else 'clear')  # Limpia la pantalla
    else:
        print("Presione cualquier tecla para continuar...")
        curses.getch()  # Espera que el usuario presione cualquier tecla
        os.system('cls' if os.name == 'nt' else 'clear')  # Limpia la pantalla

if __name__ == "__main__":
    Program()