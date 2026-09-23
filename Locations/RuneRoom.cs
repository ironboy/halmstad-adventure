
//     // An item that opens ANOTHER object's menu: just call its Run()
//     public void TalkToGuard() => _guard.Run();

//     // Prevent going east until the guard is bribed
//     public override void East()
//     {
//         if (!_guard.Bribed)
//         {
//             Console.WriteLine("The guard steps in front of you \"Not today\"");
//             Console.ReadLine();
//         }
//         else
//         {
//             // call the super class ("base") East method (in Location)
//             base.East();
//         }
//     }
// }
