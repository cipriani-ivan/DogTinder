/* tslint:disable */

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Inject, Injectable, InjectionToken, Optional } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { DefaultHttpOptions, HttpOptions, APIClientInterface } from './';
import { Appointment } from './models/appointment';
import { Dog } from './models/dog';
import { Place } from './models/place';
import { Owner } from './models/owner';

export const USE_DOMAIN = new InjectionToken<string>('APIClient_USE_DOMAIN');
export const USE_HTTP_OPTIONS = new InjectionToken<HttpOptions>(
  'APIClient_USE_HTTP_OPTIONS'
);

type APIHttpOptions = HttpOptions & {
  headers: HttpHeaders;
  params: HttpParams;
  responseType?: 'arraybuffer' | 'blob' | 'text' | 'json';
};

/**
 * Created with https://github.com/flowup/api-client-generator
 */
@Injectable()
export class APIClient implements APIClientInterface {
  readonly options: APIHttpOptions;

  readonly domain: string = `//${window.location.hostname}${
    window.location.port ? ':' + window.location.port : ''
  }`;

  constructor(
    private readonly http: HttpClient,
    @Optional() @Inject(USE_DOMAIN) domain?: string,
    @Optional() @Inject(USE_HTTP_OPTIONS) options?: DefaultHttpOptions
  ) {
    if (domain != null) {
      this.domain = domain;
    }

    this.options = {
      headers: new HttpHeaders(
        options && options.headers ? options.headers : {}
      ),
      params: new HttpParams(options && options.params ? options.params : {}),
      ...(options && options.reportProgress
        ? { reportProgress: options.reportProgress }
        : {}),
      ...(options && options.withCredentials
        ? { withCredentials: options.withCredentials }
        : {}),
    };
  }

  /**
   * Response generated for [ 200 ] HTTP response code.
   */
  getAppointment(requestHttpOptions?: HttpOptions): Observable<Appointment[]> {
    const path = `/Appointment`;
    const options: APIHttpOptions = {
      ...this.options,
      ...requestHttpOptions,
    };

    return this.sendRequest<Appointment[]>('GET', path, options);
  }

  /**
   * Response generated for [ 200 ] HTTP response code.
   */
  getDog(requestHttpOptions?: HttpOptions): Observable<Dog[]> {
    const path = `/Dog`;
    const options: APIHttpOptions = {
      ...this.options,
      ...requestHttpOptions,
    };

    return this.sendRequest<Dog[]>('GET', path, options);
  }

  /**
   * Response generated for [ 200 ] HTTP response code.
   */
  postDog(requestHttpOptions?: HttpOptions): Observable<void> {
    const path = `/Dog`;
    const options: APIHttpOptions = {
      ...this.options,
      ...requestHttpOptions,
    };

    return this.sendRequest<void>('POST', path, options);
  }

  /**
   * Response generated for [ 200 ] HTTP response code.
   */
  getOwner(requestHttpOptions?: HttpOptions): Observable<Owner[]> {
    const path = `/Owner`;
    const options: APIHttpOptions = {
      ...this.options,
      ...requestHttpOptions,
    };

    return this.sendRequest<Owner[]>('GET', path, options);
  }

  /**
   * Response generated for [ 200 ] HTTP response code.
   */
  postOwner(owner: string, requestHttpOptions?: HttpOptions): Observable<void> {
    const path = `/Owner`;
    const options: APIHttpOptions = {
      ...this.options,
      ...requestHttpOptions,
    };

    return this.sendRequest<void>('POST', path, options, owner);
  }

  /**
   * Response generated for [ 200 ] HTTP response code.
   */
  getPlace(requestHttpOptions?: HttpOptions): Observable<Place[]> {
    const path = `/Place`;
    const options: APIHttpOptions = {
      ...this.options,
      ...requestHttpOptions,
    };

    return this.sendRequest<Place[]>('GET', path, options);
  }

  /**
   * Response generated for [ 200 ] HTTP response code.
   */
  postPlace(requestHttpOptions?: HttpOptions): Observable<void> {
    const path = `/Place`;
    const options: APIHttpOptions = {
      ...this.options,
      ...requestHttpOptions,
    };

    return this.sendRequest<void>('POST', path, options);
  }

  private sendRequest<T>(
    method: string,
    path: string,
    options: HttpOptions,
    body?: any
  ): Observable<T> {
    switch (method) {
      case 'DELETE':
        return this.http.delete<T>(`${this.domain}${path}`, options);
      case 'GET':
        return this.http.get<T>(`${this.domain}${path}`, options);
      case 'HEAD':
        return this.http.head<T>(`${this.domain}${path}`, options);
      case 'OPTIONS':
        return this.http.options<T>(`${this.domain}${path}`, options);
      case 'PATCH':
        return this.http.patch<T>(`${this.domain}${path}`, body, options);
      case 'POST':
        return this.http.post<T>(`${this.domain}${path}`, body, options);
      case 'PUT':
        return this.http.put<T>(`${this.domain}${path}`, body, options);
      default:
        console.error(`Unsupported request: ${method}`);
        return throwError(`Unsupported request: ${method}`);
    }
  }
}
