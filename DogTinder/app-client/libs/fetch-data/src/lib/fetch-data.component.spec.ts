import {
  createComponentFactory,
  mockProvider,
  Spectator,
} from '@ngneat/spectator/jest';
import { FetchDataComponent } from './fetch-data.component';
import { APIClient } from '../../../../output/api-client.service';
import { Observable } from 'rxjs';
import { Appointment } from 'output/models/appointment';

describe('Appointments', () => {
  const appointments = [
    {
      appointmentId: 1,
      time: new Date(),
      place: 'Ockenburg',
      dogs: [{ name: 'Diablolik', breed: 'GSP' }],
    },
  ] as Appointment[];

  let spectator: Spectator<FetchDataComponent>;
  const createComponent = createComponentFactory({
    component: FetchDataComponent,
    detectChanges: true,
    shallow: true,
    componentProviders: [
      mockProvider(APIClient, {
        getAppointment: jest.fn().mockReturnValue(
          new Observable((subscriber) => {
            subscriber.next(appointments);
          })
        ),
      }),
    ],
  });

  it('generated component test table', () => {
    spectator = createComponent();
    expect(spectator.query('table')).toHaveClass('table-striped');
    expect(
      spectator.query(
        '[data-test=appointmentsTable] tr:first-child td:nth-child(2)'
      )?.innerHTML
    ).toContain('Ockenburg');
  });
});
