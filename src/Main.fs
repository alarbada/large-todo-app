module Main

open System
open Feliz
open Browser.Dom
open Fable.Core.JsInterop

importSideEffects "./styles/global.scss"

type Item =
  { id: int;
    name: string;
    date: DateTime }

type State = { items: Item [] }

type Actions =
  | AddItem of Item
  | RemoveItem of int

type InputProps = { onEnter: string -> unit }

[<ReactComponent>]
let Input ({ onEnter = onEnter }) =

  let text, setText = React.useState ""

  Html.div [
    prop.children [
      Html.input [
        prop.onInput (fun event -> setText event.target?value)
      ]

      Html.button [
        prop.text "Add item"
        prop.onClick (fun _ -> onEnter text)
      ]
    ]
  ]

type ItemProps =
  {| name: string;
     date: DateTime;
     onDelete: unit -> unit |}

[<ReactComponent>]
let ItemComponent (item: ItemProps) =
  Html.div [
    Html.p (item.name + " " + item.date.ToString())
    Html.button [
      prop.onClick (fun _ -> item.onDelete ())
      prop.text "Delete pls"
    ]
  ]


let reducer state =
  function
  | AddItem item ->
    { state with
        items = Array.append state.items [| item |] }
  | RemoveItem id ->
    { state with
        items = Array.filter (fun item -> item.id <> id) state.items }

let initialState = { items = [||] }

let createItem =
  let mutable id = 0

  fun text ->
    id <- id + 1

    { id = id;
      name = text;
      date = DateTime.Now }


[<ReactComponent>]
let App () =

  let state, dispatch =
    React.useReducer (reducer, initialState)

  Html.div [
    prop.children [
      Html.p "hola"
      Input { onEnter = fun text -> createItem text |> AddItem |> dispatch }
      for item in state.items do
        ItemComponent
          {| name = item.name;
             date = item.date;
             onDelete = fun _ -> RemoveItem item.id |> dispatch |}
    ]
  ]

ReactDOM.render (App(), document.getElementById "feliz-app")
