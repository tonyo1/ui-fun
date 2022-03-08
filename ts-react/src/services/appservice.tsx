import { Dispatch, SetStateAction } from "react";

export function getSomething(setliveValue: Dispatch<SetStateAction<string>>, args: object) {
  console.log(args);

  setliveValue(" works here ");

}

