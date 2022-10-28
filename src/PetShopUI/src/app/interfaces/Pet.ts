import { Owner } from "./Owner";

export interface Pet {
  id: number;
  name: string;
  reasonForTreatment: string;
  heathState: number;
  ownerId?: number;
  ownerDTO?: Owner;
  accommodationNumber: number;
}
