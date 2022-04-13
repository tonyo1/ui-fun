import { Dispatch, SetStateAction } from "react";

export function getSomething(
  setliveValue: Dispatch<SetStateAction<string>>,
  args: object
) {
  console.log(args);

  //  https://api.coindesk.com/v1/bpi/currentprice.json
  setliveValue(" works here ");
}
