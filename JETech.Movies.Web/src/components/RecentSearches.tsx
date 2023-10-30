import React from 'react';

type RecentSearchesProps = {
  searches: string[];
};

const RecentSearches: React.FC<RecentSearchesProps> = ({ searches }) => {
  return (
    <div className="bg-gray-100 p-4 rounded-md w-1/3">
      <h2 className="text-xl font-semibold mb-4">Recent Searches</h2>
      <ul>
        {searches.map((search, index) => (
          <li key={index} className="mb-2 text-gray-700">
            {search}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default RecentSearches;