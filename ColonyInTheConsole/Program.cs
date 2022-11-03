// See https://aka.ms/new-console-template for more information

using ColonyInTheConsole;


Window window = new Window();
Scene scene = new Scene(100, 100);

Person p = new Person("John Thomas", 34, 'X');
scene.AddEntity(p);

Game.Start(scene);


