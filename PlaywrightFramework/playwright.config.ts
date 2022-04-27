import { PlaywrightTestConfig } from "@playwright/test";

const config: PlaywrightTestConfig = {
  use: {
    headless: false,
    baseURL: "https://localhost:44345",
  },
};

export default config;
