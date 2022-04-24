import { Dog } from "./dog";

export interface Appointment {
  appointmentId: number;
  time: Date;
  place: string;
  dogs: Dog[];
}
