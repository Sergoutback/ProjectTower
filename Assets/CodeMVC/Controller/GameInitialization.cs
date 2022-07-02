using CodeMVC.Player;
using CodeMVC.UserInput;
using UnityEngine;

namespace CodeMVC.Controller
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data.Data data)
        {
            Camera camera = Camera.main;

            var inputFactory = new MobileInputFactory(data.Input);
            var inputInitialization = new InputInitialization(inputFactory);


            var playerFactory = new PlayerFactory(data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory, data.Player.Prefab.Position);
            
            //var enemyFactory = new EnemyFactory(data.Enemy);
            //var enemyInitialization = new EnemyInitialization(enemyFactory);
            
           controllers.Add(inputInitialization);
           controllers.Add(playerInitialization);
           controllers.Add(new PlayerController(inputInitialization.GetInput(), playerInitialization.GetPlayer()));
           
           //controllers.Add(enemyInitialization);
           
           controllers.Add(new CameraInitialization(camera.transform, data.Player.Prefab.Position));
           controllers.Add(new CameraController(playerInitialization.GetPlayer(), camera.transform));
           
           controllers.Add(new InputController(inputInitialization.GetInput()));
           //controllers.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemies(), playerInitialization.GetPlayer()));
           //controllers.Add(new EndGameController(enemyInitialization.GetEnemies(), playerInitialization.GetPlayer().gameObject.GetInstanceID()));
        }
    }
}
