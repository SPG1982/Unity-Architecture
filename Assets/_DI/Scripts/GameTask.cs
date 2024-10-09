using System.Threading.Tasks;
using UnityEngine;

public abstract class GameTask : ScriptableObject
{
    public abstract Task Do();
}

[CreateAssetMenu(
        fileName = "Task «Register Components»",
        menuName = "GameTasks/Task «Register Components»"
    )]
public sealed class GameTask_RegisterComponents : GameTask
{
    public override Task Do()
    {
        var installer = FindObjectOfType<GameContextInstaller>();
        installer.RegisterComponents();
        //await Task.Delay(10000);
        return Task.CompletedTask;
    }
}

[CreateAssetMenu(
       fileName = "Task «Construct Game»",
       menuName = "GameTasks/Task «Construct Game»"
   )]
public sealed class GameTask_ConstructGame : GameTask
{
    public override Task Do()
    {
        var installer = FindObjectOfType<GameContextInstaller>();
        installer.ConstructGame();
        return Task.CompletedTask;
    }
}

[CreateAssetMenu(
        fileName = "Task «Start Game»",
        menuName = "GameTasks/Task «Start Game»"
    )]
public sealed class GameTask_StartGame : GameTask
{
    public override Task Do()
    {
        var gameContext = FindObjectOfType<GameContext>();
        gameContext.StartGame();
        return Task.CompletedTask;
    }
}


//public enum TagManager
//{
//    OFF = 0,
//    PLAY = 1,
//    PAUSE = 2,
//    FINISH = 3,
//}

//[CreateAssetMenu(
//        fileName = "Task «Construct Game»",
//        menuName = "GameTasks/Task «Construct Game»"
//    )]
//public sealed class GameTask_ConstructGame : GameTask
//{
//    public override Task Do()
//    {
//        var gameContext = GameObject
//            .FindGameObjectWithTag(TagManager.GAME_CONTEXT)
//            .GetComponent<GameContext>();

//        var installers = GameObject
//            .FindGameObjectsWithTag(TagManager.GAME_INSTALLER);

//        foreach (var installer in installers)
//        {
//            if (installer.TryGetComponent(out IGameServiceProvider serviceProvider))
//            {
//                gameContext.AddServices(serviceProvider.GetServices());
//            }

//            if (installer.TryGetComponent(out IGameListenerProvider listenerProvider))
//            {
//                gameContext.AddListeners(listenerProvider.GetListeners());
//            }
//        }

//        foreach (var installer in installers)
//        {
//            if (installer.TryGetComponent(out IGameConstructor constructor))
//            {
//                constructor.ConstructGame(gameContext);
//            }
//        }

//        return Task.CompletedTask;
//    }
//}

//[CreateAssetMenu(
//       fileName = "Task «Start Game»",
//       menuName = "GameTasks/Task «Start Game»"
//   )]
//public sealed class GameTask_StartGame : GameTask
//{
//    public override Task Do()
//    {
//        GameObject
//            .FindGameObjectWithTag(TagManager.GAME_CONTEXT)
//            .GetComponent<GameContext>()
//            .StartGame();

//        return Task.CompletedTask;
//    }
//}
