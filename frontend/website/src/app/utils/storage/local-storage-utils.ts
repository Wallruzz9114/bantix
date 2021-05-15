import { environment } from './../../../environments/environment';

export class LocalStorageUtils {
  public static getUserToken(): string | null {
    return localStorage.getItem(environment.userToken);
  }

  public static getAgencyToken(): string | null {
    return localStorage.getItem(environment.agencyToken);
  }

  public static clearStorage(): void {
    localStorage.clear();
  }
}
