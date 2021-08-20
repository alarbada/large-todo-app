module Test100

let add x y = x + y

let sub x y = y - x

let test =
  add 3 4 |> add 2 |> sub 3 |> sub 4 |> sub 4

let thisisfast = Test20.Test2011.add 3 4

let user =
  {| name = Test20.Test2011.AddItem "asdfasdf";
     age = Test20.Test2011.AddItem "asdfasdf" |}
