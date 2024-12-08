import os
import subprocess
import sys

def clear_screen():
    input("Presione cualquier tecla para continuar...")
    os.system('cls' if os.name == 'nt' else 'clear')

def execute_command(command):
    subprocess.run(command, shell=True)

def view_files():
    current_directory = os.getcwd()
    files = os.listdir(current_directory)
    for file in files:
        print(file)

def change_directory():
    print("EJEMPLO : C:/Ruta/de/su/archivo")
    print("Coloque la ruta en la que desea moverse")
    path = input()
    path = path.replace("/", "\\")

    # Verificar si la ruta existe
    if os.path.exists(path):
        os.chdir(path)
        print(f"Ahora estas en la ruta: {os.getcwd()}")
        clear_screen()
    else:
        print("El directorio no existe. Asegúrate de que la ruta sea correcta.")
        clear_screen()

def create_project():
    print("Coloque el nombre de su carpeta")
    folder_name = input()
    print("Coloque el nombre de su archivo")
    file_name = input()

    folder_path = os.path.join(os.getcwd(), folder_name)

    # Verificar si la carpeta existe
    if not os.path.exists(folder_path):
        os.makedirs(folder_path)
    else:
        print("La carpeta ya esta creada, intenta otra vez.")

    file_path = os.path.join(folder_path, f"{file_name}.py")

    # Verificar si el archivo existe
    if not os.path.exists(file_path):
        with open(file_path, 'w') as file:
            pass
        print(f"Se ha creado el archivo {file_name} dentro de la carpeta {folder_name}.")
    else:
        print("El archivo ya existe en esa ubicación.")

def run_python_file():
    print("Coloque el nombre de su archivo : ")
    file_name = input()

    # Verificar si el archivo tiene la extensión '.py'
    if not file_name.endswith(".py"):
        file_name += ".py"

    # Verificar si el archivo existe
    if os.path.exists(file_name):
        command = f"python {file_name}"
        execute_command(command)
        clear_screen()
    else:
        print("ERROR 404: No se logro encontrar el archivo deseado")
        clear_screen()

def main():
    while True:
        print("""
                 ____       _                   ____               
                |  _ \  ___| |__  _   _  __ _  |  _ \ _   _ _ __  
                | | | |/ _ \ '_ \| | | |/ _` | | |_) | | | | '_ \ 
                | |_| |  __/ |_) | |_| | (_| | |  _ <| |_| | | | |
                |____/ \___|_.__/ \__,_|\__, | |_| \_\\__,_|_| |_| 
                                        |___/          
                                             ____        _   _                 
                                            |  _ \ _   _| |_| |__   ___  _ __  
                                            | |_) | | | | __| '_ \ / _ \| '_ \ 
                                            |  __/| |_| | |_| | | | (_) | | | |
                                            |_|    \__, |\__|_| |_|\___/|_| |_| 
                                                   |___/       
                    Version : BETA 3.7      BY : Ismaelxd74     github : https://github.com/ismaelhtmljs
                        Repositorio del programa : https://github.com/ismaelhtmljs/Debug-run-Python
            """)
        print("Para salir coloque 'exit' ")
        print("[1] Depurar")
        print("[2] Ver Archivos")
        print("[3] Moverse de Escritorio")
        print("[4] Abrir vscode")
        print("[5] Crear Proyecto")

        option = input()

        if option == "1":
            run_python_file()
        elif option == "2":
            view_files()
            clear_screen()
        elif option == "3":
            change_directory()
        elif option == "4":
            execute_command("code .")
            clear_screen()
        elif option == "5":
            create_project()
            clear_screen()
        elif option == "exit":
            sys.exit(0)
        else:
            print("ERROR: No tenemos esa opción en el programa")
            clear_screen()

if __name__ == "__main__":
    main()
