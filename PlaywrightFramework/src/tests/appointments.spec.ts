import { test, expect } from "@playwright/test";
import { ExampleClass } from "../pages/appointments.page";

test("Navigate to fetch-data", async ({ page }) => {
  await page.goto("/fetch-data");
  const url = page.url();
  expect(url).toContain("fetch-data");
});

test("Search for Breed", async ({ page }) => {
  await page.goto("/fetch-data");
  let exampletest = new ExampleClass(page);
  var text = await exampletest.getBreedText();
  expect(text).toContain("Ockenburg");
});
