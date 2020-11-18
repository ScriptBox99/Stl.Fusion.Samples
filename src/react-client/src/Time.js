import React from "react";
import formatDate from "date-fns/format";
import Section from "./Section";
import useFusionSubscription from "./lib/useFusionSubscription";

export default function TimeSection() {
  return (
    <Section title="Time (React)">
      <Time />
    </Section>
  );
}

function Time() {
  const { data, loading, error, cancel } = useFusionSubscription(
    "/api/Time/get"
  );

  return loading ? (
    "Loading..."
  ) : error ? (
    "There was an error!"
  ) : (
    <div>
      {formatDate(new Date(data), "yyyy-MM-dd HH:mm:ss.SSS xxx")}
      <span className="inline-flex ml-3 align-text-top rounded-md shadow-sm">
        <button
          type="button"
          className="inline-flex items-center px-1 text-xs font-medium leading-4 text-white transition duration-150 ease-in-out bg-gray-600 border border-transparent rounded hover:bg-gray-500 focus:outline-none focus:border-gray-700 focus:shadow-outline-gray active:bg-gray-700"
          onClick={cancel}
        >
          Cancel Wait
        </button>
      </span>
    </div>
  );
}