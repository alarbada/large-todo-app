module New

open Test87
open Test86
open Test85
open Test84
open Test83
open Test82
open Test81
open Test80
open Test79
open Test78
open Test77
open Test76
open Test75
open Test74
open Test73
open Test72
open Test71
open Test70
open Test69
open Test68
open Test67
open Test66
open Test65

let user: User = { name = "Guillem"; age = 24 }

let OtherUser =
  {| name = Test8750.Actions.Name "Guillem";
     age = Test8750.Actions.Age 24 |}

let things = {| name = "another god damn user" |}

let listofthings =
  [ for i in 1 .. 100 do
      things ]

let anotherThing =
  for thing in listofthings do
    let expr =
      if thing.name <> "guillem" then
        "wow"
      else
        "lol"

    printfn $"{expr}"


let anotherThing2 = Test4.Test41.mul 3 4
