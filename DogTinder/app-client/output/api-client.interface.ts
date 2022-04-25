/* tslint:disable */

import { Observable } from 'rxjs';
import { HttpOptions } from './';
import { Appointment } from './models/appointment';

export interface APIClientInterface {
  /**
   * Response generated for [ 200 ] HTTP response code.
   */
  getAppointment(requestHttpOptions?: HttpOptions): Observable<Appointment[]>;
}
