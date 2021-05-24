import { environment } from './../../../environments/environment';

export class LocalStorageUtils {
  public static getUserToken(): string | null {
    return localStorage.getItem(environment.userToken);
  }

  public static getAgentToken(): string | null {
    return localStorage.getItem(environment.agentToken);
  }

  public static clearStorage(): void {
    localStorage.clear();
  }
}
