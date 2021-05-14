import { environment } from './../../../environments/environment';

export class LocalStorageUtils {
  public static getUserToken(): string | null {
    return localStorage.getItem(environment.userKey);
  }

  public static getAgencyToken(): string | null {
    return localStorage.getItem(environment.agencyKey);
  }

  public static clearStorage(): void {
    localStorage.clear();
  }
}
