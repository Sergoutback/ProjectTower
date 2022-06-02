using CodeMVC.Enemy;
using CodeMVC.Model;
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
            
            var playerModel = new PlayerModel(data.Player.Sprite, data.Player.Speed, data.Player.Position, data.Player.Name);
            var playerFactory = new PlayerFactory(playerModel);
            var playerInitialization = new PlayerInitialization(playerFactory, playerModel.Position);
            
            //var enemyFactory = new EnemyFactory(data.Enemy);
            //var enemyInitialization = new EnemyInitialization(enemyFactory);
            
           controllers.Add(inputInitialization);
           controllers.Add(playerInitialization);
           //controllers.Add(enemyInitialization);
           
           controllers.Add(new CameraInitialization(camera.transform, playerModel.Position));
           controllers.Add(new CameraController(playerInitialization.GetPlayer(), camera.transform));
           
           controllers.Add(new InputController(inputInitialization.GetInput()));
           controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), playerModel));
           //controllers.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemies(), playerInitialization.GetPlayer()));
           //controllers.Add(new EndGameController(enemyInitialization.GetEnemies(), playerInitialization.GetPlayer().gameObject.GetInstanceID()));
        }
    }
}
