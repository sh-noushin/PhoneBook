import { Gender } from "./gender";

export interface ContactWithDetailsFilter {

  anyFilter: string,
  name: string,
  lName : string,
  phoneNumber : string,
  Gender: Gender,
  teamName : string,
  directBossFullName : string
  
  }
 